set "projects=Passenger.Tests Passenger.Tests.EndToEnd"
(for %%a in (%projects%) do (
  echo Running tests %%a
  dotnet test %%a/%%a.csproj
  )
)
pause
