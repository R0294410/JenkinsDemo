package Helpers;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
public class PortKiller {
    public static void StopApplication() {
        String port = "5086";
        try {
            // Find the process ID using the port
            Process findProcess = Runtime.getRuntime().exec("netstat -ano | findstr :" + port);
            BufferedReader reader = new BufferedReader(new InputStreamReader(findProcess.getInputStream()));
            String line;
            String pid = null;

            while ((line = reader.readLine()) != null) {
                if (line.contains("LISTENING")) {
                    String[] tokens = line.trim().split("\\s+");
                    pid = tokens[tokens.length - 1];
                    break;
                }
            }

            if (pid != null) {
                // Kill the process using the found PID
                Process killProcess = Runtime.getRuntime().exec("taskkill /PID " + pid + " /F");
                BufferedReader killReader = new BufferedReader(new InputStreamReader(killProcess.getInputStream()));
                while ((line = killReader.readLine()) != null) {
                    System.out.println(line);
                }
            } else {
                System.out.println("No process found using port " + port);
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
