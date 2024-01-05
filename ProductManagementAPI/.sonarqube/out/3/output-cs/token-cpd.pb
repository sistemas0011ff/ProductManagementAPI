“
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\Configuration\ApiSettings.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
Configuration. ;
{ 
public 

class 
ApiSettings 
{ 
public 
string 
? 
BaseUrl 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
	Endpoints 
? 
	Endpoints #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
}		 †
qD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\Configuration\Endpoints.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
Configuration. ;
{ 
public 

class 
	Endpoints 
{ 
public 
string 
? 
Discount 
{  !
get" %
;% &
set' *
;* +
}, -
} 
} €
sD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\Configuration\FileService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Infrastructure' 5
.5 6
Configuration6 C
{ 
public 

class 
FileService 
: 
IFileService +
{ 
public 
async 
Task 
< 
string  
>  !
	ReadAsync" +
(+ ,
string, 2
filePath3 ;
); <
{ 	
if		 
(		 
!		 
File		 
.		 
Exists		 
(		 
filePath		 %
)		% &
)		& '
{

 
return 
null 
; 
} 
using 
( 
var 
reader 
= 
File  $
.$ %
OpenText% -
(- .
filePath. 6
)6 7
)7 8
{ 
return 
await 
reader #
.# $
ReadToEndAsync$ 2
(2 3
)3 4
;4 5
} 
} 	
public 
async 
Task 

WriteAsync $
($ %
string% +
filePath, 4
,4 5
string6 <
content= D
)D E
{ 	
var 
	directory 
= 
Path  
.  !
GetDirectoryName! 1
(1 2
filePath2 :
): ;
;; <
if 
( 
! 
	Directory 
. 
Exists !
(! "
	directory" +
)+ ,
), -
{ 
	Directory 
. 
CreateDirectory )
() *
	directory* 3
)3 4
;4 5
} 
await 
File 
. 
WriteAllTextAsync (
(( )
filePath) 1
,1 2
content3 :
): ;
;; <
} 	
} 
} ‘
ÅD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\Configuration\ProductRepositorySettings.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
Configuration. ;
{ 
public 

class %
ProductRepositorySettings *
{ 
public 
string 
FilePath 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
FilePathStates $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} ê#
oD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\HttpClients\ApiClient.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
HttpClients. 9
{ 
public 

class 
	ApiClient 
: 

IApiClient '
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
private		 
readonly		 !
JsonSerializerOptions		 .
_serializerOptions		/ A
;		A B
public 
	ApiClient 
( 

HttpClient #

httpClient$ .
,. /!
JsonSerializerOptions0 E
serializerOptionsF W
)W X
{ 	
_httpClient 
= 

httpClient $
??% '
throw( -
new. 1!
ArgumentNullException2 G
(G H
nameofH N
(N O

httpClientO Y
)Y Z
)Z [
;[ \
_serializerOptions 
=  
serializerOptions! 2
??3 5
throw6 ;
new< ?!
ArgumentNullException@ U
(U V
nameofV \
(\ ]
serializerOptions] n
)n o
)o p
;p q
} 	
public 
async 
Task 
< 
T 
? 
> 
GetAsync &
<& '
T' (
>( )
() *
string* 0
url1 4
)4 5
where6 ;
T< =
:> ?
class@ E
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
url* -
)- .
). /
{ 
throw 
new 
ArgumentException +
(+ ,
$str, O
,O P
nameofQ W
(W X
urlX [
)[ \
)\ ]
;] ^
} 
var 
response 
= 
await  
_httpClient! ,
., -
GetAsync- 5
(5 6
url6 9
)9 :
.: ;
ConfigureAwait; I
(I J
falseJ O
)O P
;P Q
if 
( 
! 
response 
. 
IsSuccessStatusCode -
)- .
{ 
throw 
new  
HttpRequestException .
(. /
$"/ 1
$str1 R
{R S
responseS [
.[ \

StatusCode\ f
}f g
"g h
)h i
;i j
} 
var   
content   
=   
await   
response    (
.  ( )
Content  ) 0
.  0 1
ReadAsStringAsync  1 B
(  B C
)  C D
.  D E
ConfigureAwait  E S
(  S T
false  T Y
)  Y Z
;  Z [
return"" 
DeserializeContent"" %
<""% &
T""& '
>""' (
(""( )
content"") 0
)""0 1
;""1 2
}## 	
private%% 
T%% 
?%% 
DeserializeContent%% %
<%%% &
T%%& '
>%%' (
(%%( )
string%%) /
content%%0 7
)%%7 8
where%%9 >
T%%? @
:%%A B
class%%C H
{&& 	
if'' 
('' 
string'' 
.'' 
IsNullOrWhiteSpace'' )
('') *
content''* 1
)''1 2
)''2 3
{(( 
return)) 
default)) 
;)) 
}** 
try,, 
{-- 
return.. 
JsonSerializer.. %
...% &
Deserialize..& 1
<..1 2
T..2 3
>..3 4
(..4 5
content..5 <
,..< =
_serializerOptions..> P
)..P Q
;..Q R
}// 
catch00 
(00 
JsonException00  
ex00! #
)00# $
{11 
throw33 
new33 %
InvalidOperationException33 3
(333 4
$str334 _
,33_ `
ex33a c
)33c d
;33d e
}44 
}55 	
}66 
}77 ú
oD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\interfaces\IApiClient.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .

Interfaces. 8
{ 
public 

	interface 

IApiClient 
{ 
Task 
< 
T 
? 
> 
GetAsync 
< 
T 
> 
( 
string #
url$ '
)' (
where) .
T/ 0
:1 2
class3 8
;8 9
} 
} à
qD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\interfaces\IFileService.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Infrastructure' 5
.5 6

interfaces6 @
{ 
public 

	interface 
IFileService !
{ 
Task 
< 
string 
> 
	ReadAsync 
( 
string %
filePath& .
). /
;/ 0
Task 

WriteAsync 
( 
string 
filePath '
,' (
string) /
content0 7
)7 8
;8 9
} 
} ã
yD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\repositories\DiscountRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
repositories. :
{ 
public 

class 
DiscountRepository #
:$ %
IDiscountRepository& 9
{ 
private		 
readonly		 

IApiClient		 #

_apiClient		$ .
;		. /
public 
DiscountRepository !
(! "

IApiClient" ,
	apiClient- 6
,6 7
string8 >
discountEndpoint? O
)O P
{ 	

_apiClient 
= 
	apiClient "
??# %
throw& +
new, /!
ArgumentNullException0 E
(E F
nameofF L
(L M
	apiClientM V
)V W
)W X
;X Y
} 	
public 
async 
Task 
< 
DiscountDto %
>% &&
GetDiscountForProductAsync' A
(A B
stringB H
	productIdI R
)R S
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
	productId* 3
)3 4
)4 5
{ 
throw 
new 
ArgumentException +
(+ ,
$str, V
,V W
nameofX ^
(^ _
	productId_ h
)h i
)i j
;j k
} 
try 
{ 
var 
discount 
= 
await $

_apiClient% /
./ 0
GetAsync0 8
<8 9
DiscountDto9 D
>D E
(E F
$"F H
{H I
$strI T
}T U
$strU V
{V W
	productIdW `
}` a
"a b
)b c
;c d
return 
discount 
??  "
throw# (
new) ,%
InvalidOperationException- F
(F G
$"G I
$strI b
{b c
	productIdc l
}l m
$strm y
"y z
)z {
;{ |
} 
catch 
( 
	Exception 
ex 
)  
{ 
throw 
new %
InvalidOperationException 3
(3 4
$"4 6
$str6 p
{p q
	productIdq z
}z {
$str{ }
"} ~
,~ 
ex
Ä Ç
)
Ç É
;
É Ñ
} 
}   	
}## 
}$$ Ô>
xD:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\repositories\ProductRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
repositories. :
{ 
public		 

class		 
ProductRepository		 "
:		# $
IProductRepository		% 7
{

 
private 
readonly 
string 
	_filePath  )
;) *
private 
readonly 
IFileService %
_fileService& 2
;2 3
public 
ProductRepository  
(  !
string! '
filePath( 0
,0 1
IFileService2 >
fileService? J
)J K
{ 	
	_filePath 
= 
filePath  
??! #
throw$ )
new* -!
ArgumentNullException. C
(C D
nameofD J
(J K
filePathK S
)S T
)T U
;U V
_fileService 
= 
fileService &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
fileServiceQ \
)\ ]
)] ^
;^ _
} 	
public 
async 
Task 
AddAsync "
(" #$
ProductInfrastructureDto# ;
product< C
)C D
{ 	
var 
products 
= 
await  
ReadAllAsync! -
(- .
). /
;/ 0
products 
. 
Add 
( 
product  
)  !
;! "
await 
WriteAllAsync 
(  
products  (
)( )
;) *
} 	
public 
async 
Task 
< 
IEnumerable %
<% &$
ProductInfrastructureDto& >
>> ?
>? @
GetAllAsyncA L
(L M
)M N
{ 	
return 
await 
ReadAllAsync %
(% &
)& '
;' (
} 	
public 
async 
Task 
< $
ProductInfrastructureDto 2
>2 3
GetByIdAsync4 @
(@ A
stringA G
	productIdH Q
)Q R
{ 	
var   
products   
=   
await    
ReadAllAsync  ! -
(  - .
)  . /
;  / 0
var!! 
product!! 
=!! 
products!! "
.!!" #
FirstOrDefault!!# 1
(!!1 2
p!!2 3
=>!!4 6
p!!7 8
.!!8 9
	ProductId!!9 B
==!!C E
	productId!!F O
)!!O P
;!!P Q
if## 
(## 
product## 
==## 
null## 
)##  
{$$ 
throw%% 
new%%  
KeyNotFoundException%% .
(%%. /
$"%%/ 1
$str%%1 J
{%%J K
	productId%%K T
}%%T U
$str%%U V
"%%V W
)%%W X
;%%X Y
}&& 
return(( 
product(( 
;(( 
})) 	
public++ 
async++ 
Task++ 
UpdateAsync++ %
(++% &$
ProductInfrastructureDto++& >
product++? F
)++F G
{,, 	
var-- 
products-- 
=-- 
await--  
ReadAllAsync--! -
(--- .
)--. /
;--/ 0
var.. 
productToUpdate.. 
=..  !
products.." *
...* +
FirstOrDefault..+ 9
(..9 :
p..: ;
=>..< >
p..? @
...@ A
	ProductId..A J
==..K M
product..N U
...U V
	ProductId..V _
).._ `
;..` a
if// 
(// 
productToUpdate// 
!=//  "
null//# '
)//' (
{00 
products11 
.11 
Remove11 
(11  
productToUpdate11  /
)11/ 0
;110 1
products22 
.22 
Add22 
(22 
product22 $
)22$ %
;22% &
await33 
WriteAllAsync33 #
(33# $
products33$ ,
)33, -
;33- .
}44 
}55 	
public77 
async77 
Task77 
DeleteAsync77 %
(77% &
string77& ,
	productId77- 6
)776 7
{88 	
var99 
products99 
=99 
await99  
ReadAllAsync99! -
(99- .
)99. /
;99/ 0
var:: 
productToDelete:: 
=::  !
products::" *
.::* +
FirstOrDefault::+ 9
(::9 :
p::: ;
=>::< >
p::? @
.::@ A
	ProductId::A J
==::K M
	productId::N W
)::W X
;::X Y
if;; 
(;; 
productToDelete;; 
!=;;  "
null;;# '
);;' (
{<< 
products== 
.== 
Remove== 
(==  
productToDelete==  /
)==/ 0
;==0 1
await>> 
WriteAllAsync>> #
(>># $
products>>$ ,
)>>, -
;>>- .
}?? 
}@@ 	
privateBB 
asyncBB 
TaskBB 
<BB 
ListBB 
<BB  $
ProductInfrastructureDtoBB  8
>BB8 9
>BB9 :
ReadAllAsyncBB; G
(BBG H
)BBH I
{CC 	
varDD 
fileContentDD 
=DD 
awaitDD #
_fileServiceDD$ 0
.DD0 1
	ReadAsyncDD1 :
(DD: ;
	_filePathDD; D
)DDD E
;DDE F
ifEE 
(EE 
stringEE 
.EE 
IsNullOrEmptyEE $
(EE$ %
fileContentEE% 0
)EE0 1
)EE1 2
{FF 
returnGG 
newGG 
ListGG 
<GG  $
ProductInfrastructureDtoGG  8
>GG8 9
(GG9 :
)GG: ;
;GG; <
}HH 
returnJJ 
JsonSerializerJJ !
.JJ! "
DeserializeJJ" -
<JJ- .
ListJJ. 2
<JJ2 3$
ProductInfrastructureDtoJJ3 K
>JJK L
>JJL M
(JJM N
fileContentJJN Y
)JJY Z
??JJ[ ]
newJJ^ a
ListJJb f
<JJf g$
ProductInfrastructureDtoJJg 
>	JJ Ä
(
JJÄ Å
)
JJÅ Ç
;
JJÇ É
}KK 	
privateMM 
asyncMM 
TaskMM 
WriteAllAsyncMM (
(MM( )
ListMM) -
<MM- .$
ProductInfrastructureDtoMM. F
>MMF G
productsMMH P
)MMP Q
{NN 	
varPP 
optionsPP 
=PP 
newPP !
JsonSerializerOptionsPP 3
{QQ 
WriteIndentedRR 
=RR 
trueRR  $
,RR$ %
EncoderSS 
=SS 
SystemSS  
.SS  !
TextSS! %
.SS% &
	EncodingsSS& /
.SS/ 0
WebSS0 3
.SS3 4
JavaScriptEncoderSS4 E
.SSE F%
UnsafeRelaxedJsonEscapingSSF _
}TT 
;TT 
varVV 
contentVV 
=VV 
JsonSerializerVV (
.VV( )
	SerializeVV) 2
(VV2 3
productsVV3 ;
,VV; <
optionsVV= D
)VVD E
;VVE F
awaitWW 
_fileServiceWW 
.WW 

WriteAsyncWW )
(WW) *
	_filePathWW* 3
,WW3 4
contentWW5 <
)WW< =
;WW= >
}XX 	
}YY 
}ZZ ì
}D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductContextInfraestructure\repositories\ProductStateRepository.cs
	namespace 	 
ProductManagementAPI
 
. 
Product &
.& '
Infrastructure' 5
.5 6
repositories6 B
{ 
public 

class "
ProductStateRepository '
:( )#
IProductStateRepository* A
{		 
private

 
readonly

 
string

 
	_filePath

  )
;

) *
private 
readonly 
IFileService %
_fileService& 2
;2 3
public "
ProductStateRepository %
(% &
string& ,
filePath- 5
,5 6
IFileService7 C
fileServiceD O
)O P
{ 	
	_filePath 
= 
filePath  
??! #
throw$ )
new* -!
ArgumentNullException. C
(C D
nameofD J
(J K
filePathK S
)S T
)T U
;U V
_fileService 
= 
fileService &
??' )
throw* /
new0 3!
ArgumentNullException4 I
(I J
nameofJ P
(P Q
fileServiceQ \
)\ ]
)] ^
;^ _
} 	
public 
async 
Task 
< 
IEnumerable %
<% &)
ProductStateInfrastructureDto& C
>C D
>D E!
GetProductStatesAsyncF [
([ \
)\ ]
{ 	
var 
fileContent 
= 
await #
_fileService$ 0
.0 1
	ReadAsync1 :
(: ;
	_filePath; D
)D E
;E F
if 
( 
string 
. 
IsNullOrEmpty $
($ %
fileContent% 0
)0 1
)1 2
{ 
return 
new 
List 
<  )
ProductStateInfrastructureDto  =
>= >
(> ?
)? @
;@ A
} 
var 
estadosWrapper 
=  
JsonSerializer! /
./ 0
Deserialize0 ;
<; <
EstadosWrapper< J
>J K
(K L
fileContentL W
)W X
;X Y
return 
estadosWrapper !
?! "
." #
Estados# *
??+ -
new. 1
List2 6
<6 7)
ProductStateInfrastructureDto7 T
>T U
(U V
)V W
;W X
} 	
} 
} 