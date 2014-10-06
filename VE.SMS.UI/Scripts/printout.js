var hkey_root,hkey_path,hkey_key;
hkey_root="HKEY_CURRENT_USER";
<!--地址的写法很严格的用双斜杠-->
hkey_path="\Software\Microsoft\Internet Explorer\PageSetup";
//设置网页打印的页眉页脚为空
function pagesetup_null(){
try{
var RegWsh = new ActiveXObject("WScript.Shell");
hkey_key="\header";
RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"");
hkey_key="\footer";
RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"");
}catch(e){}
}
//设置网页打印的页眉页脚为默认值
function pagesetup_default(){
try{
var RegWsh = new ActiveXObject("WScript.Shell");
hkey_key="\header" ;
RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"&w&b页码,&p/&P");
hkey_key="\footer";
RegWsh.RegWrite(hkey_root+hkey_path+hkey_key,"&u&b&d");
}catch(e){}
}
function printsetup(){  
 wb.execwb(8,1); // 打印页面设置
} 
function printpreview(){  
 wb.execwb(7,1);// 打印页面预览
} 
function printit() { 
 if (confirm('确定打印吗？')) { 
  wb.execwb(6,1);
 } 
} 