import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Songs from './Songs/Songs.js';
import './App.css';
import Playlists from "./Playlists";
import Artists from "./Artists/Artists";
import Albums from "./Albums/Albums";
import MainPage from "./MainPage";
import Album from "./Albums/Album";
import Artist from "./Artists/Artist";

var tokenStr = 'token=';
var token = tokenStr + 'BQBd7In-IpKJG-gYjy17jHTEuNx24Z4_IJmVxskhGP0Yhq7gmNYufXUN7bTIUjEAK68CNMwhkgubaUSxjO4w8fUCn1f4w-DNVQ-gXha_7q_VqRrPNWGHeJZImRS5_aBeW96DT9nDza579VLB8j-KAvSBzkKimvsWidQfcjh2XHrd67yYaEcRwq6OGN-mZXGyQ3TLUPf9uwQOmB098RBmhA0e3l9VkAKMrUD_QkejRtl_-uQcVR7f4ay35LN41ddeILFys_kDF5-GwXSIPhfh-JQ5E-EL';

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
                        <Route exact path="/playlists" component={Playlists}/>
                        <Route exact path="/artists" component={Artists}/>
                        <Route exact path="/albums" component={Albums}/>
                        <Route path='/albums/album/:albumId' component={Album}/>
                        <Route path='/artists/artist/:artistId' component={Artist}/>
                    </Switch>
                </Router>
            </div>);
    }

}

export default App;
