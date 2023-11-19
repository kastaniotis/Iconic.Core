#!/bin/bash
dotnet build -c Release
dotnet pack -c Release --runtime linux-x64 -o ./nuget