import React, { useEffect, useState } from "react";

interface FlashMessageProps {
    title: string;
    description?: string;
    timeout?: number;
    onClose: () => void;
}

const FlashMessage: React.FC<FlashMessageProps> = ({ title, description, timeout = 1000, onClose }) => {
    const [visible, setVisible] = useState<boolean>(false);

    useEffect(() => {
        setVisible(true);

        const timer = setTimeout(() => {
            setVisible(false);
            onClose();
        }, timeout);

        return () => clearTimeout(timer);
    }, [onClose, timeout]);

    return (
        <div className={`flash ${visible ? 'active' : ''}`}>
            <h4>{title}</h4>
            {description && <p>{description}</p>}
        </div>
    );
};

export default FlashMessage;
