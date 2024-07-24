package Helpers;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.concurrent.Executors;
import java.util.concurrent.ExecutorService;

public class DotnetLauncherHelper {

    public static void StartApplication() {
        String s = null;

        System.out.println("Hello StartApplication method!");
        try {
            // specify the directory of your Blazor WASM application
            String projectDirectory = "../Server";
            System.out.println("Launching server...");

            // run the Unix "dotnet run" command using the Runtime exec method:
            Process p = Runtime.getRuntime().exec("dotnet run", null, new File(projectDirectory));

            ExecutorService executorService = Executors.newFixedThreadPool(2);

            // Handle standard output
            executorService.submit(() -> {
                try (BufferedReader stdInput = new BufferedReader(new InputStreamReader(p.getInputStream()))) {
                    String line;
                    while ((line = stdInput.readLine()) != null) {
                        System.out.println(line);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });

            // Handle error output
            executorService.submit(() -> {
                try (BufferedReader stdError = new BufferedReader(new InputStreamReader(p.getErrorStream()))) {
                    String line;
                    while ((line = stdError.readLine()) != null) {
                        System.out.println(line);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            });

            // Wait for the application to be fully started by checking the health status
            System.out.println("About to call waitForHealthCheck method...");
            if (waitForHealthCheck("http://localhost:5086/health", 60, 5)) {
                System.out.println("Application is up and running.");
            } else {
                throw new RuntimeException("Application did not start within the expected time.");
            }

        } catch (IOException e) {
            System.out.println("Exception: ");
            e.printStackTrace();
        }
    }

    private static boolean waitForHealthCheck(String url, int maxWaitTimeInSeconds, int sleepIntervalInSeconds) {
        int attempts = 0;
        int maxAttempts = maxWaitTimeInSeconds / sleepIntervalInSeconds;

        System.out.println("Hello health check waiter!");
        while (attempts < maxAttempts) {
            System.out.println("Attempt #" + (attempts + 1));
            if (isApplicationHealthy(url)) {
                return true;
            }
            attempts++;
            try {
                Thread.sleep(sleepIntervalInSeconds * 1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        return false;
    }

    private static boolean isApplicationHealthy(String urlString) {
        System.out.println("Hello Health Checker! Checking URL: " + urlString);
        try {
            URL url = new URL(urlString);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("GET");
            connection.setConnectTimeout(5000);
            connection.setReadTimeout(5000);

            int responseCode = connection.getResponseCode();
            System.out.println("Health check response code: " + responseCode);
            if (responseCode == 200) {
                return true;
            }
        } catch (IOException e) {
            System.out.println("Health check failed: " + e.getMessage());
        }
        return false;
    }
}