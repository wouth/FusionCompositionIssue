dotnet graphql download http://localhost:7201/api/graphql -f Subgraph1\schema.graphql
@if errorlevel 1 goto fail
dotnet graphql download http://localhost:7202/api/graphql -f Subgraph2\schema.graphql
@if errorlevel 1 goto fail

@echo off
del /s /q *.fsp
del /s /q *.fgp
dotnet fusion subgraph pack -w Subgraph1
if errorlevel 1 goto fail
dotnet fusion subgraph pack -w Subgraph2
if errorlevel 1 goto fail

dotnet fusion compose -p .\Gateway\gateway.fgp -s .\Subgraph1\ -s .\Subgraph2\
if errorlevel 1 goto fail
copy .\Gateway\*.fgp .\Gateway\bin\Debug\net8.0
if errorlevel 1 goto fail
@echo The gateway was created!
dotnet graphql download http://localhost:7200/api/graphql -f Gateway\schema.graphql
@if errorlevel 1 goto downloadGraySchemaFail
goto end
:fail
@echo Error creating the gateway!
goto end
:downloadGraySchemaFail
@echo Error downloading the gateway schema!
:end
