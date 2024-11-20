import React from "react";
import {Link} from "react-router-dom";

interface ButtonProps {
  text: string;
  onClick?: () => void;
  disabled?: boolean;
  link?: boolean;
  color: 'blue' | 'red' | 'gray' | 'answer';
  to?: string;
  width?: string;
}

const Button: React.FC<ButtonProps> = (
    {
        text,
        onClick = () => {},
        disabled = false,
        color,
        link = false,
        to = '',
        width = 'auto'
    }
) => {
    return link ? (
        <Link className={"button" + " button-" + color} to={to} style={{ width }}>
            {text}
        </Link>
    ) : (
        <button className={"button" + " button-" + color} onClick={onClick} disabled={disabled} style={{ width }}>
            {text}
        </button>
    );
}

export default Button;