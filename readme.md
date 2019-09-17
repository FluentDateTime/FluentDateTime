# <img src="/src/icon.png" height="30px"> FluentDateTime

[![Build status](https://ci.appveyor.com/api/projects/status/me89rbu5iv976k2q/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/fluentdatetime)
[![NuGet Status](https://img.shields.io/nuget/v/FluentDateTime.svg?label=FluentDateTime&cacheSeconds=86400)](https://www.nuget.org/packages/FluentDateTime/)

Allows cleaner DateTime expressions and operations.

Inspired by Ruby DateTime Extensions

 * [Extensions To Datetime](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-datetime)
 * [Extensions To Time](http://edgeguides.rubyonrails.org/active_support_core_extensions.html#extensions-to-time)


## NuGet

https://nuget.org/packages/FluentDateTime/


## Usage

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


## Icon

[Calendar](http://thenounproject.com/noun/calendar/#icon-No404) from The Noun Project