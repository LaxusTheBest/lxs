$("button[name='moveright']").click(moveright);

$("button[name='moveleft']").click(moveleft);

$("button[name='moveallright'").click(moveallright);

$("button[name='moveallleft']").click(moveallleft);

function moveleft() {
    $("select[name='rigthSelect'] option:selected").each(function () {
        var str = this.outerHTML;
        $("select[name=leftSelect]").append(str);
        $("select[name=rigthSelect] option:selected").remove();
    });
};

function moveright() {
    $("select[name='leftSelect'] option:selected").each(function () {
        var str = this.outerHTML;
        $("select[name=rigthSelect]").append(str);
        $("select[name=leftSelect] option:selected").remove();
    });
};

function moveallright() {
    $("select[name='leftSelect'] option").each(function () {
        var str = this.outerHTML;
        $("select[name=rigthSelect]").append(str);
        $("select[name=leftSelect] option").remove();
    });
};

function moveallleft() {
    $("select[name='rigthSelect'] option").each(function () {
        var str = this.outerHTML;
        $("select[name=leftSelect]").append(str);
        $("select[name=rigthSelect] option").remove();
    });
};