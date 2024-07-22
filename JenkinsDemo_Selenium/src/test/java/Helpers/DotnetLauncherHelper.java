package Helpers;

import java.io.*;

public class DotnetLauncherHelper {
    public static void StartApplication(String args[]) {
        String s = null;

        try {
            // specify the directory of your Blazor WASM application
            String projectDirectory = "../Client";

            // run the Unix "dotnet run" command
            // using the Runtime exec method:
            Process p = Runtime.getRuntime().exec("dotnet run", null, new File(projectDirectory));

            BufferedReader stdInput = new BufferedReader(new InputStreamReader(p.getInputStream()));
            BufferedReader stdError = new BufferedReader(new InputStreamReader(p.getErrorStream()));

            // read the output from the command
            System.out.println("Here is the standard output of the command:\n");
            while ((s = stdInput.readLine()) != null) {
                System.out.println(s);
            }

            // read any errors from the attempted command
            System.out.println("Here is the standard error of the command (if any):\n");
            while ((s = stdError.readLine()) != null) {
                System.out.println(s);
            }
        } catch (IOException e) {
            System.out.println("Exception: ");
            e.printStackTrace();
        }
    }
}
