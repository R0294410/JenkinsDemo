package Helpers;

import org.junit.BeforeClass;

public class TestscriptHelper {
    public static boolean applicationIsLaunched = false;

    @BeforeClass
    public static void SetupApplicationLocally(){
        DotnetLauncherHelper.StartApplication();
        try {
            Thread.sleep(10000);
            applicationIsLaunched = true;
        }catch (InterruptedException ex){
            ex.printStackTrace();
        }
    }
}
