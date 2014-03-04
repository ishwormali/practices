
var Test = Require<F14N>()
    .Init<FluentAutomation.SeleniumWebDriver>()
    .Bootstrap("Chrome")
    .Config(settings => {
        // Easy access to FluentAutomation.Settings values
        settings.DefaultWaitUntilTimeout = TimeSpan.FromSeconds(1);
    });
  
Test.Run("Hello Google", I => {
    I.Open("http://google.com");
    
});

