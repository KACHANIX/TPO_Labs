import {Link} from "react-router-dom";
import React, {Component, useContext} from "react";
import './MainMenu.css';
import {api} from "./GetToken";

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
        this.setState({name: me.display_name, followers: me.followers.total});
    }

    render() {
        return (
            <div>
                <div>
                    {this.state.name != '' &&
                    <div id='welcome-msg'>
                        Welcome, {this.state.name}.<br/>
                        Your followers: {this.state.followers}
                    </div>
                    }

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