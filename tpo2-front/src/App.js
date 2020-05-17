import React, {Component} from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import logo from './logo.svg';
import Songs from './Songs.js';
import './App.css';
import Playlists from "./Playlists";
import Artists from "./Artists";
import Albums from "./Albums";
import MainPage from "./MainPage";
import AuthContext from './AuthContext';

class App extends Component {
    constructor() {
        super();
        const params = this.getHashParams();
        console.log(params.access_token);
        this.state={
            authToken: params.access_token
        }
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
                <AuthContext.Provider value={this.state.authToken}>
                    <Router>
                        <Switch>
                            <Route exact path="/" component={MainPage}/>
                            <Route path="/songs" component={Songs}/>
                            <Route path="/playlists" component={Playlists}/>
                            <Route path="/artists" component={Artists}/>
                            <Route path="/albums" component={Albums}/>
                        </Switch>
                    </Router>
                </AuthContext.Provider>
            </div>);
    }

}

export default App;
