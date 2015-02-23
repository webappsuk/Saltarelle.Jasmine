properties {
	$baseDir = Resolve-Path ".."
    $buildtoolsDir = Resolve-Path "."
	$outDir = "$(Resolve-Path "".."")\Jasmine\bin"
	$configuration = "Debug"
	$version = "0.0." + + (git describe --tags --long).split('-')[1]
}

Task default -Depends Build-NuGetPackages

Task Clean {
	if (Test-Path $outDir) {
		rm -Recurse -Force "$outDir" >$null
	}
	md "$outDir" >$null
}

Task Build-Jasmine -Depends Clean {
	Exec { msbuild "$baseDir\Saltarelle.Jasmine.sln" /verbosity:minimal /p:"Configuration=$configuration" }
}

Task Build-NuGetPackages -Depends Build-Jasmine {
@"
<package xmlns="http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd">
	<metadata>
		<id>Saltarelle.Jasmine</id>
		<version>$version</version>
		<title>Saltarelle.Jasmine</title>
		<description>This package contains the required metadata to use Jasmine with the Saltarelle C# to JavaScript compiler. Install this package on the C# saltarelle project.</description>
		<authors>Antonino Porcino</authors>
		<projectUrl>https://github.com/nippur72/Saltarelle.Jasmine</projectUrl>
	</metadata>
	<files>
		<file src="$outDir\$configuration\Saltarelle.Jasmine.dll" target="lib"/>
		<file src="$outDir\$configuration\Saltarelle.Jasmine.xml" target="lib"/>
	</files>
</package>
"@ | Out-File -Encoding UTF8 "$outDir\Saltarelle.Jasmine.$version.nuspec"

	Exec { & "$buildtoolsDir\nuget.exe" pack "$outDir\Saltarelle.Jasmine.$version.nuspec" -NoPackageAnalysis -OutputDirectory "$outDir" }
}