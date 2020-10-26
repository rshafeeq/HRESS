/***BLINKING***/
window.onerror = null;
var bName = navigator.appName;
var bVer = parseInt(navigator.appVersion);
var NS4 = (bName == "Netscape" && bVer >= 4);
var IE4 = (bName == "Microsoft Internet Explorer" && bVer >= 4);
var NS3 = (bName == "Netscape" && bVer < 4);
var IE3 = (bName == "Microsoft Internet Explorer" && bVer < 4);
var blink_speed=300;
var i=0;
 
if (NS4 || IE4) 
{
    if (navigator.appName == "Netscape") 
    {
        layerStyleRef="layer.";
        layerRef="document.layers";
    styleSwitch="";
    }
    else
    {
        layerStyleRef="layer.style.";
        layerRef="document.all";
        styleSwitch=".style";
    }
}        

function Blink(layerName)
{
    if (NS4 || IE4) 
    { 
        if(i%2==0)
        {
            eval(layerRef+'["'+layerName+'"]'+
            styleSwitch+'.visibility="visible"');
        }
        else
        {
            eval(layerRef+'["'+layerName+'"]'+
            styleSwitch+'.visibility="hidden"');
        }
    } 
    if(i<1)
    {
        i++;
    } 
    else
    {
        i--
    }
    setTimeout("Blink('"+layerName+"')",blink_speed);
}       

function isNumber(field) 
{
	var re = /^[0-9-' ']*$/;
	if (!re.test(field.value)) 
	{
	    alert("Value must be numbers, letter(s) not allowed!");
	    field.value = field.value.replace(/[^0-9-' ']/g,"");	        
	}
	else
	{
	    try
	    {
	        document.DPAX.EmpNo = field.value;
	        document.getElementById('hdEmpNo').value = field.value;
	    }
	    catch (e) {
	        alert(e);
	    }
	}
}

function test()
{
    document.getElementById('hdDPAX').value = document.DPAX.Result;
}

function DPAX_InitProps()
{
    var empno = document.getElementById('hdEmpNo').value;
    try
    {
        document.DPAX.EmpNo = empno; 
    }
    catch(e)
    {
        
    }
}

/*** Edit Section ***/
function categorychg()
{
    var rval = document.all("cmbCategory").value;
    document.all("hdCategory").value = rval;
    //alert(document.all("hdCategory").value);    
}
function subcat1chg()
{
    var rval = document.all("cmbSubCategory1").value;
    document.all("hdSubCategory1").value = rval;
    //alert(document.all("hdSubCategory1").value);    
}
function subcat2chg()
{
    var rval = document.all("cmbSubCategory2").value;
    document.all("hdSubCategory2").value = rval;
    //alert(document.all("hdSubCategory2").value);    
}
function subcat3chg()
{
    var rval = document.all("cmbSubCategory3").value;
    document.all("hdSubCategory3").value = rval;
    //alert(document.all("hdSubCategory3").value);    
}
function brandchg()
{
    var rval = document.all("cmbBrand").value;
    document.all("hdBrand").value = rval;
    //alert(document.all("hdBrand").value);    
    try
    {
        document.all("txtBrandCode").innerText = rval;
    }
    catch(e)
    {
    }
}
/*** End of Edit Section ***/
