function IsVehicleEmpty() {
    if(document.getElementById('TxtVehicle').value == "") {
        return 'Vehicle should not be empty';
    }
    else {
        return "";
    }
}

function IsVehicleInvalid() {
    if (document.getElementById('TxtVehicle').value.indexOf("@") != -1) {
        return 'Vehicle should not contain @';
    }
    else {
        return "";
    }
}

function IsCustomerEmpty() {
    if (document.getElementById('TxtCustomer').value == "") {
        return 'Customer should not be empty';
    }
    else {
        return "";
    }
}

function IsCustomerInvalid() {
    if (document.getElementById('TxtCustomer').value.length < 2) {
        return 'Customer should have more than one letter';
    }
    else {
        return "";
    }
}

function IsRequestedEmpty() {
    if (document.getElementById('TxtRequested').value == "") {
        return 'Requested should not be empty';
    }
    else {
        return "";
    }
}

function IsRequestedInvalid() {
    var date_regex = /^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
    var result = date_regex.test(document.getElementById('TxtRequested').value);
    if (!(result)) {
        return 'Requested should be in the format of MM/dd/yyyy';
    }
    else {
        return "";
    }
}

function IsBuiltEmpty() {
    if (document.getElementById('TxtBuilt').value == "") {
        return 'Built should not be empty';
    }
    else {
        return "";
    }
}

function IsBuiltInvalid() {
    var date_regex = /^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
    var result = date_regex.test(document.getElementById('TxtBuilt').value);
    if (!(result)) {
        return 'Built should be in the format of MM/dd/yyyy';
    }
    else {
        return "";
    }
}

function IsValid() {
    var VehicleEmptyMessage = IsVehicleEmpty();
    var VehicleInvalidMessage = IsVehicleInvalid();
    var CustomerEmptyMessage = IsCustomerEmpty();
    var CustomerInvalidMessage = IsCustomerInvalid();
    var RequestedEmptyMessage = IsRequestedEmpty();
    var RequestedInvalidMessage = IsRequestedInvalid();
    var BuiltEmptyMessage = IsBuiltEmpty();
    var BuiltInvalidMessage = IsBuiltInvalid();

    var FinalErrorMessages = "Errors:";
    if (VehicleEmptyMessage != "")
        FinalErrorMessages += "\n" + VehicleEmptyMessage;
    if (VehicleInvalidMessage != "")
        FinalErrorMessages += "\n" + VehicleInvalidMessage;
    if (CustomerEmptyMessage != "")
        FinalErrorMessages += "\n" + CustomerEmptyMessage;
    if (CustomerInvalidMessage != "")
        FinalErrorMessages += "\n" + CustomerInvalidMessage;
    if (RequestedEmptyMessage != "")
        FinalErrorMessages += "\n" + RequestedEmptyMessage;
    if (RequestedInvalidMessage != "")
        FinalErrorMessages += "\n" + RequestedInvalidMessage;
    if (BuiltEmptyMessage != "")
        FinalErrorMessages += "\n" + BuiltEmptyMessage;
    if (BuiltInvalidMessage != "")
        FinalErrorMessages += "\n" + BuiltInvalidMessage;

    if (FinalErrorMessages != "Errors:") {
        alert(FinalErrorMessages);
        return false;
    }
    else {
        return true;
    }
}