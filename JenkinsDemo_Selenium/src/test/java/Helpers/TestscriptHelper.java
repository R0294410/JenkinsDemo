package Helpers;

import org.junit.BeforeClass;

public class TestscriptHelper {

    @BeforeClass
    public static void SetupApplicationLocally(){
        DotnetLauncherHelper.StartApplication();
        try {
            Thread.sleep(10000);
        }catch (InterruptedException ex){
            ex.printStackTrace();
        }
    }
}
