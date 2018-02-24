md bin
md config

copy PicSo.exe.config .\config
copy Entity.dll .\bin
copy Gets.dll .\bin
copy HtmlAgilityPack.dll .\bin

del PicSo.exe.config
del Entity.dll
del Gets.dll
del HtmlAgilityPack.dll
del Entity.pdb
del Gets.pdb
del PicSo.pdb

del removeDLL.bat