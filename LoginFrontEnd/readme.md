### Download 
To just download the required projects use the following batch file.

```batch
mkdir code
cd code
git init
git remote add -f origin https://github.com/karenpayneoregon/WorkingWithAccessDatabases
git sparse-checkout init --cone
git sparse-checkout add ConfigurationLibrary_vb
git sparse-checkout add LoginFrontEnd
git sparse-checkout add LoginLibrary
git pull origin master
:clean-up
del .gitattributes
del .gitignore
del .yml
del .editorconfig
del *.md
del *.sln

```