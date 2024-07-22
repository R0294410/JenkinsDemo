package Glue;

import Helpers.BaseUtil;
import Helpers.TestscriptHelper;
import io.cucumber.java.Scenario;
import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.After;
import org.junit.Before;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

public class Hooks extends BaseUtil{

    private BaseUtil baseUtil;
    private TestscriptHelper scriptHelper;

    public Hooks(BaseUtil baseUtil) {
        this.baseUtil = baseUtil;
    }

    @Before
    public void InitializeTest(){
        WebDriverManager.chromedriver().setup();
        ChromeOptions chromeOptions = new ChromeOptions();
        baseUtil.driver = new ChromeDriver(chromeOptions);
        baseUtil.driver.manage().window().maximize();
    }

    @After
    public void TeardownTest(Scenario scenario) {
        if (scenario.isFailed()) {
            System.out.println(scenario.getName());
        }
        System.out.println("Closing the browser : MOCK");
        baseUtil.driver.quit();
    }
}
