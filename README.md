# WebApi.HttpOptions

WebApi.HttpOptions adds automatic handling for the HTTP `OPTIONS` and `HEAD` verbs to your [WebAPI](http://www.asp.net/web-api) applications.

NuGet package:
* [WebApi.HttpOptions](https://www.nuget.org/packages/WebApi.HttpOptions/)



## Usage

Add `config.EnableHttpOptions();` to your `WebApiConfig.cs` file. Any URI that is configured to respond to other HTTP verbs will now also repsond to `HTTP OPTIONS` with an `Allow` header listing the available verbs.

Add `config.EnableHttpHead();` to your `WebApiConfig.cs` file. Any URI that is configured to respond to `HTTP GET` will now also respond to `HTTP HEAD` with the same headers and no body.

Add `config.EnableVersionHeader();` to your `WebApiConfig.cs` file. All responses will now include an `X-YourApp-Version` header.



## Sample project

The source code includes a sample project that uses demonstrates the usage of WebApi.HttpOptions. You can build and run it using Visual Studio 2015. By default the instance will be hosted by IIS Express at `http://localhost:4727/`.
