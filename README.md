# Browser
Cef cef.redist.x86.75.1.14 Browser with proprietary_codecs

	https://bitbucket.org/chromiumembedded/cef/wiki/MasterBuildQuickStart.md#markdown-header-windows-setup
	
	set CEF_USE_GN=1
	set GN_DEFINES=is_official_build=true proprietary_codecs=true ffmpeg_branding=Chrome
	set GYP_DEFINES=buildtype=Official
	set GYP_MSVS_VERSION=2017
	set CEF_ARCHIVE_FORMAT=tar.bz2
	set GN_ARGUMENTS=--ide=vs2017 --sln=cef --filters=//cef/*
	python automate-git.py --download-dir=D:\gws\cef\build_3770 --branch=3770 --force-build --force-clean --minimal-distrib --client-distrib
