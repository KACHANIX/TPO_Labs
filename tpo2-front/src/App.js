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
import {getCookie, setCookie} from "./GetToken";

class App extends Component {
    constructor() {
        super();
        const params = this.getHashParams(); //params.access_token
        let cookie = getCookie();
        // console.log(params.access_token);
        if (cookie == '' && params.access_token == undefined) {
            window.location.href = 'http://localhost:8888/login/';
            return;
        }
        if (params.access_token != undefined)
            setCookie(params.access_token)
            // document.cookie = tokenStr + params.access_token;
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
