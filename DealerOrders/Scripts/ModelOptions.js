$(function () {
    $('#ModelId').change(function () {
        var selectedModelName = $("#ModelId option:selected").text();
        $("#TxtVehicle").val(selectedModelName);

        var URL = $('#ModelOptionFormID').data('optionListAction'.toLowerCase());
        var modelId = $('#ModelId').val();
        var action = URL + '/' + modelId;
        $.getJSON(
            action,
            function (data) {
                $("#OptionId").empty();
                $("#OptionId").append('<option value="' + "0" + '">' + "-- Select Option(s) --" + '</option>')
                $.each(data, function (idx, modelOption) {
                    $("#OptionId").append('<option value="' + modelOption.Value + '">' + modelOption.Text + '</option>')
                });

            });
    });

    $('#OptionId').change(function () {
        var selectedOptions = $(this).children("option:selected").map(function () {
            return $(this).text();
        }).get().join();
        $("#TxtOptions").val(selectedOptions);
    });
})