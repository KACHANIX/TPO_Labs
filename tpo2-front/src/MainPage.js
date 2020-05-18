import {Link} from "react-router-dom";
import React, {Component, useContext} from "react";
import './MainMenu.css';

class MainPage extends Component {
    constructor(props) {
        super(props);
    }

    componentDidMount() {
        const asd = this.context;
        console.log(asd);
    }

    render() {
        return (
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
        );
    }
}

export default MainPage;