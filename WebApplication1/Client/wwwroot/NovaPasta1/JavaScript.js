function alertToast(tipo, mensagem, divId) {
    $(divId).dxToast({
        type: tipo,
        message: mensagem,
        displayTime: 5000
    });

    $(divId).dxToast("show");
}
