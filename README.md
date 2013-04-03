# FluentDateTime

Partially inspired by Ruby DateTime Extensions

 * [Extensions To Datetime](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-datetime)
 * [Extensions To Time](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-time)

Allows you to write cleaner DateTime expressions and operation. For example your code can look like this:

* DateTime.Now  - 1.Weeks() - 3.Days() + 14.Minutes();
* DateTime.Now  + 5.Years();
* 3.Days().Ago();
* 2.Days().Since(DateTime.Now);
* DateTime.Now.NextDay();
* DateTime.Now.NextYear();
* DateTime.Now.PreviousYear();
* DateTime.Now.WeekAfter();
* DateTime.Now.Midnight();
* DateTime.Now.Noon();
* DateTime.Now.SetTime(11, 55, 0);

(See Unit Tests in the project for more details).

## Downloading

Download the [FluentDateTime Nuget](http://nuget.org/List/Packages/FluentDateTime) 

The latest build can be found here: [CodeBetter](http://teamcity.codebetter.com/viewLog.html?buildId=lastSuccessful&buildTypeId=bt85&tab=artifacts)

Note that these builds, while passing all tests, may not be as stable as those taken from the Downloads page. They will however have all the latest bug fixes and features. 

## Icon

<a href="http://thenounproject.com/noun/calendar/#icon-No404" target="_blank">Calendar</a>  from The Noun Project