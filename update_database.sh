#!/bin/bash

echo "Updating database..."
exec dotnet ef database update -p idobrin-aspnet-dal -s idobrin-aspnet-api
exit 0
