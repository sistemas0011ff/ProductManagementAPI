«
…D:\Eduv4\Personal\Sise\Proyectos\WCF\EFajardoRetoTecnico\ProductManagementAPI.Infrastructure.Logging\ResponseTimeLoggingMiddleware.cs
	namespace 	 
ProductManagementAPI
 
. 
Infrastructure -
.- .
Logging. 5
{ 
public 

class )
ResponseTimeLoggingMiddleware .
{		 
private

 
readonly

 
RequestDelegate

 (
_next

) .
;

. /
private 
readonly 
ILogger  
<  !)
ResponseTimeLoggingMiddleware! >
>> ?
_logger@ G
;G H
public )
ResponseTimeLoggingMiddleware ,
(, -
RequestDelegate- <
next= A
,A B
ILoggerC J
<J K)
ResponseTimeLoggingMiddlewareK h
>h i
loggerj p
)p q
{ 	
_next 
= 
next 
; 
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
)9 :
{ 	
var 
	requestId 
= 
Guid  
.  !
NewGuid! (
(( )
)) *
.* +
ToString+ 3
(3 4
)4 5
;5 6
var 
	stopwatch 
= 
	Stopwatch %
.% &
StartNew& .
(. /
)/ 0
;0 1
try 
{ 
_logger 
. 
LogInformation &
(& '
$str' W
,W X
	requestId 
, 
context &
.& '
Request' .
.. /
Method/ 5
,5 6
context7 >
.> ?
Request? F
.F G
GetDisplayUrlG T
(T U
)U V
)V W
;W X
await 
_next 
( 
context #
)# $
;$ %
	stopwatch 
. 
Stop 
( 
)  
;  !
_logger   
.   
LogInformation   &
(  & '
$str	  ' Š
,
  Š ‹
	requestId!! 
,!! 
context!! &
.!!& '
Request!!' .
.!!. /
Method!!/ 5
,!!5 6
context!!7 >
.!!> ?
Request!!? F
.!!F G
GetDisplayUrl!!G T
(!!T U
)!!U V
,!!V W
context!!X _
.!!_ `
Response!!` h
.!!h i

StatusCode!!i s
,!!s t
	stopwatch!!u ~
.!!~  
ElapsedMilliseconds	!! ’
)
!!’ “
;
!!“ ”
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
	stopwatch%% 
.%% 
Stop%% 
(%% 
)%%  
;%%  !
_logger&& 
.&& 
LogError&&  
(&&  !
ex&&! #
,&&# $
$str	&&% …
,
&&… †
	requestId'' 
,'' 
context'' &
.''& '
Request''' .
.''. /
Method''/ 5
,''5 6
context''7 >
.''> ?
Request''? F
.''F G
GetDisplayUrl''G T
(''T U
)''U V
,''V W
context''X _
.''_ `
Response''` h
.''h i

StatusCode''i s
,''s t
	stopwatch''u ~
.''~  
ElapsedMilliseconds	'' ’
)
''’ “
;
''“ ”
throw)) 
;)) 
}** 
}++ 	
},, 
}-- 