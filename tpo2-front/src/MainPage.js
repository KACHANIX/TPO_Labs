import {Link} from "react-router-dom";
import React, {Component, useContext} from "react";
import './MainMenu.css';
import * as SpotifyWebApi from 'spotify-web-api-js';
import AuthContext from './AuthContext';

var s = new SpotifyWebApi();


class MainPage extends Component {
    static contextType = AuthContext;
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        const asd = this.context;
        console.log(asd);
    }

    render() {
        return (
            <AuthContext.Consumer>
                {authToken => (
                    <div>
                        {authToken}
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
                    </div>)
                }

            </AuthContext.Consumer>
        );
    }
}

export default MainPage;