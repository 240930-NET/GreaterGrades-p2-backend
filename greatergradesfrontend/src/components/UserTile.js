import React from 'react';

const UserTile = ({ firstName, lastName, role }) => {
    return (
        <div className="user-tile">
            <h4 className="user-name">{`${firstName} ${lastName}`}</h4>
            <p className="user-role">{role}</p>
        </div>
    );
};

export default UserTile;
