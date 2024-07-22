package Helpers;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;

public class CalculatorHelper {
    public static WebDriver driver;
    public static BaseUtil baseUtil;

    public CalculatorHelper(WebDriver driver){
        this.driver = driver;
    }

    public static void InsertCalculation(ArrayList<String> calculationInserts){
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        for(int i = 0; i < calculationInserts.size(); i++){
            char[] inserts = calculationInserts.get(i).toCharArray();
            for(char insert : inserts){
                String xpathExpression = String.format("//button[@id='calcButton-%s']", insert);
                baseUtil.driver.findElement(By.xpath(xpathExpression)).click();
            }

        }
    }
}
