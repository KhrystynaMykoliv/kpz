import React, { ReactElement } from 'react';
import Button from "./Button.tsx";

interface ModalWindowProps {
    opened: boolean;
    onSubmit?: () => void;
    onClose: () => void;
    title: string;
    children: ReactElement;
}

const ModalWindow: React.FC<ModalWindowProps> = ({
                                                     opened,
                                                     onSubmit = () => {},
                                                     onClose,
                                                     title,
                                                     children
                                                 }) => {
    const modalClass = `modal ${opened ? 'active' : ''}`;

    return (
        <div className={modalClass}>
            <div className={"modal-main"}>
                <div className={"modal-header"}>
                    <h2 className={"modal-title"}>{title}</h2>
                </div>
                <div className={"modal-body"}>
                    {children}
                </div>
                <div className={"modal-actions"}>
                    <Button text="Скасувати" link={false} onClick={onClose} color="gray" />
                    <Button text="Підтвердити" link={false} onClick={onSubmit} color="blue" />
                </div>
            </div>
        </div>
    );
}

export default ModalWindow;