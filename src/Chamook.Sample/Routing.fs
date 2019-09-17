module Routing

open System
open Giraffe

let webApp: HttpHandler =
    choose [
        GET >=> route "/health" >=> text "Everything's fine here"
        RequestErrors.NOT_FOUND "Damn son"
    ]
