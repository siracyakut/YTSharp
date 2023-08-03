# YTSharp
### Introduction
YTSharp is an open-source .NET Core Web API project for searching youtube videos and fetching their information.
### Project Support Features
The following information can be fetched from a single YouTube video:
* Video Id
* Video Title
* Video Length (seconds)
* Video Channel Id
* Video Channel Name
* Video Description
* Video View Count
* Video Like Count
* Video Thumbnail

The following information can be fetched from a YouTube search:
* Video Id
* Video Title
* Video Length (seconds)
* Video Thumbnail
### API Endpoints
| HTTP Verbs | Endpoints | Action |
| --- | --- | --- |
| GET | /api/video/:videoId | To retrieve a single YouTube video info |
| GET | /api/search/:query | To search and fetch information on YouTube |
| GET | /api/search/:query/:count | To search and fetch information on YouTube by maximum count |
### Technologies Used
* [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) C# (pronounced "See Sharp") is a modern, object-oriented, and type-safe programming language.
* [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0) ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-enabled, Internet-connected apps.
* [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0) ASP.NET Web API is a framework for building HTTP services that can be accessed from any client including browsers and mobile devices.
### License
This project is available for use under the MIT License.