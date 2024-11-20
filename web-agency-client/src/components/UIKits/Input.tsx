import React from "react";

interface InputInterface {
    id: string,
    type: "text" | "file" | "tel" | "password" | "date"
    placeholder: string,
    value: never,
    onChange: (e: never) => void,
    required: boolean
}

const Input: React.FC<InputInterface> = (
    {id, type, value, placeholder, onChange, required}
) => {
    return (
        <input
            className={"input"}
            id={id}
            value={value}
            type={type}
            placeholder={placeholder}
            onChange={onChange}
            required={required}
        />
    )
}

export default Input;