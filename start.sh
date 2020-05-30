#!/bin/bash
dotnet ./DotNetCore.Sample.dll --urls http://0.0.0.0:80 &
dotnet ./DotNetCore.SubWeb.dll --urls http://0.0.0.0:8080
