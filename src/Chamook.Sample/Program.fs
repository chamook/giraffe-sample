module Program

open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open Giraffe

let configureApp (app : IApplicationBuilder) =
    app.UseGiraffe Routing.webApp

let configureServices (services : IServiceCollection) =
    services.AddGiraffe() |> ignore

let buildWebHost args =
    WebHost
        .CreateDefaultBuilder(args)
        .UseKestrel(fun c -> c.AddServerHeader <- false)
        .Configure(Action<IApplicationBuilder> configureApp)
        .ConfigureServices(configureServices)
        .Build()

[<EntryPoint>]
let main args =
    buildWebHost(args).Run()

    0
