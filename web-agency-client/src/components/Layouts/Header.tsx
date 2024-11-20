import React from "react";
import {Link} from "react-router-dom";

const Header: React.FC = () => {
    return(
        <header>
            <nav>
                <li>
                    <Link to={"/"}>Clients</Link>
                </li>
                <li>
                    <Link to={"/managers"}>Managers</Link>
                </li>
                <li>
                    <Link to={"/contracts"}>Contracts</Link>
                </li>
            </nav>
        </header>
    )
}

export default Header;