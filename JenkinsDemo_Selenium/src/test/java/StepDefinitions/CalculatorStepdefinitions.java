package StepDefinitions;

import Helpers.BaseUtil;
import Helpers.CalculatorHelper;
import Helpers.TestscriptHelper;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.And;
import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.TimeUnit;

public class CalculatorStepdefinitions {
    WebDriver driver;
    CalculatorHelper helper;
    TestscriptHelper scriptHelper;

    @Given("I navigate to the {string} page")
    public void i_navigate_to_the_page(String page) {
        if(scriptHelper.applicationIsLaunched == false) {
            TestscriptHelper.SetupApplicationLocally();
        }

        driver = new ChromeDriver();
        BaseUtil.driver = driver;

        helper = new CalculatorHelper(driver);

        String xpathButton = String.format("//a[@id='%s_btn']", page);

        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

        driver.get("http://localhost:5086/");
        driver.findElement(By.xpath(xpathButton)).click();
    }

    @When("I click on the following buttons")
    public void i_click_on_the_following_buttons(io.cucumber.datatable.DataTable tableCalculationInserts) {
        List<Map<String, String>> rows = tableCalculationInserts.asMaps(String.class, String.class);
        ArrayList<String> listCalculationInserts = new ArrayList<>();

        for(Map<String, String> calculationInserts : rows){
            for(Map.Entry<String, String> entry : calculationInserts.entrySet()){
                String insert = entry.getValue();
                listCalculationInserts.add(insert);
            }
        }
        CalculatorHelper.InsertCalculation(listCalculationInserts);
    }

    @Then("The displayed calculation is {string}")
    public void the_displayed_calculation_is(String expectedCalculation) {
        String displayedCalculation = driver.findElement(By.xpath("//input[@id='displayCalculation']")).getAttribute("value");
        Assert.assertEquals(expectedCalculation, displayedCalculation);
    }

    @When("I want to calculate the result")
    public void i_want_to_calculate_the_result() {
        driver.findElement(By.xpath("//button[@id='calcButton-=']")).click();
    }

    @Then("The result is {string}")
    public void the_result_is(String expectedResult) {
        String displayedResult = driver.findElement(By.xpath("//input[@id='calculationResult']")).getAttribute("value");
        Assert.assertEquals(expectedResult, displayedResult);
        driver.close();
    }
}
