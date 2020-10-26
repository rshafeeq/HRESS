if ($("#hdMenu").val() == "") {
}

$(".ui-state-highlight").hide();

$('#menu div').each(function (index) {
    if ($("#hdMenu").val() == $(this).text().trim()) {
        $(this).css("color", "blue");
        $("#div" + $(this).attr("id")).show();
    }
    else {
        $(this).css("color", "black");
        $("#div" + $(this).attr("id")).hide("fast");
    }
});

$(function () {
    $("#menu").menu({
        select: function (event, ui) {
            $("#lblStatus").text(ui.item.text().trim());
            $("#hdMenu").val(ui.item.text().trim());

            $('#menu div').each(function (index) {
                if ($("#hdMenu").val() == $(this).text().trim()) {
                    $(this).css("color", "blue");
                    $("#div" + $(this).attr("id")).show();
                    toggleDivs();
                    toggleButtons();
                }
                else {
                    $(this).css("color", "black");
                    $("#div" + $(this).attr("id")).hide("fast");
                }
            });
        }
    });
});

$("#divPersonalDetails").find("input[type=text]").addClass("rcorners2");
$("#divContactDetails").find("input[type=text]").addClass("rcorners2");
$("#divEmergencyContacts").find("input[type=text]").addClass("rcorners2");
$("#divReportingTo").find("input[type=text]").addClass("rcorners2");

/* Contact Details */
$("#btnCDEdit").button();
$("#btnCDEdit").click(function () {
    $("#divContactDetails").find("input[type=text]").removeClass("rcorners2");
    $("#divContactDetails").find("input[type=text]").addClass("rcorners1");
    $("#btnCDEdit").hide();
    $("#btnCDSave").show();
});

$("#btnCDSave").button();
$("#btnCDSave").click(function () {
    $("#divContactDetails").find("input[type=text]").removeClass("rcorners1");
    $("#divContactDetails").find("input[type=text]").addClass("rcorners2");
    $("#btnCDEdit").show();
    $("#btnCDSave").hide();
});
/***/

/* Emergency Contacts */

$("#btnECAdd").button();
$("#btnECDelete").button();
$("#btnECSave").button();
$("#btnECCancel").button();

$("#btnECAdd").click(function () {
    $("#divECAdd").hide();
    $("#divECEdit").show();

    $("#divECEdit").find("input[type=text]").removeClass("rcorners2");
    $("#divECEdit").find("input[type=text]").addClass("rcorners1");
});

$("#btnECSave").click(function () {
    var strErr = "";
    $(".ui-state-highlight").hide();
    if ($("#txtECName").val() == "") {
        if (strErr != "")
            strErr += "<br />";
        strErr += "Name is required.";
    }
    $(".ui-state-highlight").hide();
    if ($("#txtECRelationship").val() == "") {
        if (strErr != "")
            strErr += "<br />";
        strErr += "Relationship is required.";
    }

    if (strErr != "") {
        $("#lblNotify").html(strErr);
        $(".ui-state-highlight").show("slow");
        return false;
    }
    else {
        var txtUID = $("#txtEmployeeID").val();
        var txtName = $("#txtECName").val();
        var txtRela = $("#txtECRelationship").val();
        var txtHomeTel = $("#txtECHomeTelephone").val();
        var txtMobile = $("#txtECMobile").val();
        var txtWorktel = $("#txtECWorkPhone").val();
        $.ajax({
            type: "POST",
            url: location.pathname + "Profile.aspx/saveData",
            data: "{emp_number:'" + txtUID +
                "',eec_name:'" + txtName +
                "',eec_relationship:'" + txtRela +
                "',eec_home_no:'" + txtHomeTel +
                "',eec_mobile_no:'" + txtMobile +
                "',eec_office_no:'" + txtWorktel + "'}",
            contentType: "application/json; charset=utf-8",
            datatype: "jsondata",
            async: "true",
            success: function (response) {
                var myObject = eval('(' + response.d + ')');
                if (myObject > 0) {
                    //bindData();
                    $("#lblNotify").html("Data saved successfully.");
                    $(".ui-state-highlight").show("slow");
                }
                else {
                    $("#lblNotify").html("Opppps something went wrong.");
                    $(".ui-state-highlight").show("slow");
                }
            },
            error: function (response) {
                alert(response.status + ' ' + response.statusText);
            }
        });
    }
});

$("#btnECCancel").click(function () {
    $("#divECAdd").show();
    $("#divECEdit").hide();

    $("#divECEdit").find("input[type=text]").addClass("rcorners1");
    $("#divECEdit").find("input[type=text]").removeClass("rcorners2");

    $(".ui-state-highlight").hide();
});

/***/

function toggleDivs() {
    $("#divPersonalDetails").find("input[type=text]").removeClass("rcorners1");
    $("#divContactDetails").find("input[type=text]").removeClass("rcorners1");
    $("#divEmergencyContacts").find("input[type=text]").removeClass("rcorners1");
    $("#divReportingTo").find("input[type=text]").removeClass("rcorners1");

    $("#divPersonalDetails").find("input[type=text]").addClass("rcorners2");
    $("#divContactDetails").find("input[type=text]").addClass("rcorners2");
    $("#divEmergencyContacts").find("input[type=text]").addClass("rcorners2");
    $("#divReportingTo").find("input[type=text]").addClass("rcorners2");

    $("#divECEdit").hide();
    $("#divECAdd").show();

    $(".ui-state-highlight").hide();
}
function toggleButtons() {
    $("#btnCDSave").hide();
    $("#btnCDEdit").show();
}