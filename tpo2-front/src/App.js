import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Songs from './Songs/Songs.js';
import './App.css';
import Playlists from "./Playlists/Playlists";
import Artists from "./Artists/Artists";
import Albums from "./Albums/Albums";
import MainPage from "./MainPage";
import Album from "./Albums/Album";
import Artist from "./Artists/Artist";
import Playlist from "./Playlists/Playlist";

var tokenStr = 'token=';
var token = tokenStr + 'BQBmr670iSTSHMfGzcamPvq11mzFfsJh_o2d8UZNlddpB622nkm3E53TsHdGlf4E9F9LbnU5-N-SJu6ikeLtsq4X8zMIXl4sScK-C1-0Y2rfKG5SdkUaFSpptgna3d6sMk7XR68swAt5oxBiOdWG0f6qdpSjpsRIqYV5-76LpPf-hAFL9AMgO74HJ-oxRamjvQeDWbGaQaESLcM4MuehXDLhN_OK1gbFHEJ0ZK8MZzSGwnx0tv_AoCGbhUsKcQfxtRtgJ4a-xVf00kljHDXijdBfb0h5';

class App extends Component {
    constructor() {
        super();
        const params = this.getHashParams(); //params.access_token
        console.log(document.cookie);
        console.log(params.access_token);
        if (document.cookie == '' && params.access_token == undefined) {
            window.location.href = 'http://localhost:8888/login/';
            return;
        }

        if (params.access_token != undefined)
            document.cookie = tokenStr + params.access_token;
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
                        <Route exact path="/playlists" component={Playlists}/>
                        <Route exact path="/artists" component={Artists}/>
                        <Route exact path="/albums" component={Albums}/>
                        <Route path='/albums/album/:albumId' component={Album}/>
                        <Route path='/artists/artist/:artistId' component={Artist}/>
                        <Route path='/playlists/playlist/:playlistId' component={Playlist}/>
                    </Switch>
                </Router>
            </div>);
    }

}

export default App;
