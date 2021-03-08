import React, {useState} from "react";
import { useHistory } from "react-router-dom";
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { Button } from '@material-ui/core';
import TextField from '@material-ui/core/TextField';

const CreateReservationDialog = () => {
    const [open, setOpen] = useState(false);
    const [firstName, setFirstName] = useState();
    const [lastName, setLastName] = useState();
    const [email, setEmail] = useState();
    const [phone, setPhone] = useState();
    const history = useHistory();

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    const handleNext = async () => {

        const data = {
            firstName: firstName,
            lastName: lastName,
            phone: phone,
            email: email
        }

        const response = await fetch("https://localhost:5001/api/users/", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const content = await response.json();

        if(content) {
            setOpen(false);
            history.push(`reservation/${content.id}`);
        }

    }


    return (
        <div>
            <Button className="res-button" variant="contained" color="primary" onClick={handleClickOpen}>Make reservation</Button>
            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <DialogTitle id="form-dialog-title">Subscribe</DialogTitle>
                <DialogContent>
                    <DialogContentText>
                        First, please enter your information
                    </DialogContentText>
                    <TextField
                        autoFocus
                        margin="dense"
                        id="FirstName"
                        label="First name"
                        type="text"
                        fullWidth
                        onChange={e => setFirstName(e.target.value)}
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        id="LastName"
                        label="Last name"
                        type="text"
                        fullWidth
                        onChange={e => setLastName(e.target.value)}
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        id="Phone"
                        label="Phone number"
                        type="text"
                        fullWidth
                        onChange={e => setPhone(e.target.value)}
                    />
                    <TextField
                        autoFocus
                        margin="dense"
                        id="Email"
                        label="Email Address"
                        type="text"
                        fullWidth
                        onChange={e => setEmail(e.target.value)}
                    />
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color="primary">Cancel</Button>
                    <Button onClick={handleNext} color="primary">Next</Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}

export default CreateReservationDialog;