function AutoComplate(obj, len, param) {
    var ctl = $(obj);
    var val = ctl.val();
    var ctlId = ctl.attr("id");
    if (val.length == 0) {
        $("#" + ctlId + "_Auto").hide();
        return;
    }
    if (val.length < len)
        return;
    var div = $("#" + ctlId + "_Auto");
    if (div.length == 0) {
        div = $("<div id=\"" + ctlId + "_Auto\" style =\"position:absolute; display:none; border:1px solid #817f82; background-color:#ffffff; width:200px\"></div>");
        $('body').append(div);
    }
    param["__EVENTTARGET"] = ctlId;
    param[ctlId] = val;
    var wu_nopar = window.location.href.split("?")[0].split("/");
    var pageName = wu_nopar[wu_nopar.length - 1];
    $.post(pageName + "?action=list", param, function(data) {
        var result = eval(data);
        if (result.length > 0) {
            div.html("");
            var table = $("<table style='width:100%' ><tbody></tbody></table>");
            for (var i = 0; i < result.length; i++) {
                var tr = $("<tr><td >" + result[i] + "</td></tr>");
                tr.mouseover(function() {
                    $(this).addClass('JZac');
                });
                tr.mouseout(function() {
                    $(this).removeClass('JZac');
                });
                tr.click(function() {
                    $(obj).val($(this).children().eq(0).html());
                    div.hide();
                });
                table.append(tr);
            }
            div.append(table);
            var of = $(obj).offset();
            var top = of.top + $(obj).height();
            div.css("top", top + 5);
            div.css("left", of.left);
            div.width($(obj).width());
            div.show();
        }
        else
            div.hide();
    });
}
