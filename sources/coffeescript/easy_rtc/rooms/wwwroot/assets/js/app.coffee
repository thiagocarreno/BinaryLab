class App

    constructor: ->
        easyrtc.connect "easyrtc.instantMessaging", @onSuccessConnect, @onErrorConnect

    onSuccessConnect: (easyRtcId) =>
        debugger
        console.log "Connection ID: #{easyRtcId}."
        easyrtc.joinRoom "test-room", null, @onSuccessJoin, @onErrorJoin

    onErrorConnect: (errorCode, message) =>
        console.log "ErrorCode: #{errorCode}, Message: #{message}."

    onSuccessJoin: =>
        console.log "Join."

    onErrorJoin: =>
        console.log "Not Join."

app = new App