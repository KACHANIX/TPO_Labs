import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Songs from './Songs.js';
import './App.css';
import Playlists from "./Playlists";
import Artists from "./Artists";
import Albums from "./Albums";
import MainPage from "./MainPage";

var tokenStr = 'token=';
var token = tokenStr + 'BQDptDfdaaZdAERMtN5FwZGQUJfWqxchoxmb1UzZt43Z4PlmhyPhbp3nUn3BdNW2NjVDMAkHlsCe2rbxmE-a792S-ALdysCGZM7SmN6Ln1mjUdsVtWKykGL04L1G05_TrTAffTSygVZj3n4KupEvG7Zq2-jmEe8SCxa8rMzBN5OCXWHpHxLLOCHrCzjqgkAOcT6JukSRb6OE-hUV9tDpv9kjNJEcesEl3TXy7LeZ616exb-jBgnVSMMFr-V_o91fhzCb0q8yJDXD_9ycU_UPINl6TRKv';

class App extends Component {
    constructor() {
        super();
        const params = this.getHashParams(); //params.access_token
        // console.log('foo');
        // console.log(params.access_token);
        document.cookie = token;
    }

    getHashParams() {
        var hashParams = {};
        var e, r = /([^&;=]+)=?([^&;]*)/g,
            q = window.location.hash.substring(1);
        e = r.exec(q)
        while (e) {
            hashParams[e[1]] = decodeURIComponent(e[2]);
            e = r.exec(q);
        }
        return hashParams;
    }

    render() {
        return (
            <div className="App">
                <Router>
                    <Switch>
                        <Route exact path="/" component={MainPage}/>
                        <Route path="/songs" component={Songs}/>
                        <Route path="/playlists" component={Playlists}/>
                        <Route path="/artists" component={Artists}/>
                        <Route path="/albums" component={Albums}/>
                    </Switch>
                </Router>
            </div>);
    }

}

export default App;
