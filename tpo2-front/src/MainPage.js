import {Link} from "react-router-dom";
import React, {Component, useContext} from "react";
import './MainMenu.css';
import api from "./GetToken";

class MainPage extends Component {

    constructor() {
        super();
        this.state = {
            name: '',
            followers: 0
        };
    }

    async componentDidMount() {

        let Api = api();
        let me = null;
        await Api.getMe().then(function (data) {
            me = data;
        });
        console.log(me);

        document.getElementById('welcome-msg').innerText = 'Welcome, ' + me.display_name + '\n Your followers : ' + me.followers.total;
    }

    render() {
        return (
            <div>
                <div id='welcome-msg'>
                </div>
                <div id="main-menu-block">
                    <div className="links-line">
                        <Link to="songs">Songs</Link>
                        <Link class="link" to="playlists">Playlists</Link>
                    </div>
                    <div className="links-line">
                        <Link to="artists">Artists</Link>
                        <Link class="link" to="albums">Albums</Link>
                    </div>
                </div>
            </div>
        );
    }
}

export default MainPage;