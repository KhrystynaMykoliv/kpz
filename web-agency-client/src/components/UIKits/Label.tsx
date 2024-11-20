import React from 'react';

interface LabelProps {
    id: string;
    text: string;
    likeLink?: boolean;
}

const Label: React.FC<LabelProps> = ({ id, text, likeLink = false }) => {
    const labelClass = `label ${likeLink ? "link" : ''}`;

    return (
        <label className={labelClass} htmlFor={id}>
            {text}
        </label>
    );
};

export default Label;
