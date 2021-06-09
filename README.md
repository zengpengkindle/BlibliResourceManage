# BlibliResourceManage

b站客户端 自愿整理 
用B站客户端 下载的视频 如果想用其他更好的播放器播放发现 资源很乱 这个小demo可以一键吧所有的视频整理归档好

dotnet publish -r win10-x64 /p:PublishSingleFile=true

在解决方案目录下（blibli.csproj） 执行以上语句 必须.net core 环境 

会在 win10-64/publish/ 下生成可执行文件  将这个可执行文件放入 B站自愿对应的目录下即可自动整理
