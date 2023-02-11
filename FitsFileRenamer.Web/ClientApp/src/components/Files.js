import React, {Component} from 'react';

export class Files extends Component {
    static displayName = Files.name;

    constructor(props) {
        super(props);
        this.state = {files: [], path: 'F:\\TEMP\\LIGHT', loading: true};
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
    }

    handleChange(event) {
        this.setState({ path: event.target.value });
    }

    async handleSubmit(event) {
        this.populateFilesData();
        event.preventDefault();
    }

    static renderFiles(files) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                <tr>
                    <th>FullPathName</th>
                    <th>Date</th>
                    <th>Date UTC</th>
                    <th>Filter</th>
                    <th>Exposure</th>
                    <th>Type</th>
                    <th>Gain</th>
                    <th>Set Temp</th>
                    <th>Actual Temp</th>
                </tr>
                </thead>
                <tbody>
                {files.map(file =>
                    <tr key={file.fullPathNamme}>
                        <td>{file.fullPathNamme}</td>
                        <td>{file.date}</td>
                        <td>{file.dateUtc}</td>
                        <td>{file.filter}</td>
                        <td>{file.exposure}</td>
                        <td>{file.imageType}</td>
                        <td>{file.gain}</td>
                        <td>{file.setTemperature}</td>
                        <td>{file.actualTemperature}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Files.renderFiles(this.state.files);

        return (
            <div>
                <h1 id="tableLabel">Files</h1>
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.path} onChange={this.handleChange} />
                    <input type="submit" value="Submit" onSubmit={this.submit} />
                </form>
                {contents}
            </div>
        );
    }

    async populateFilesData() {
        const response = await fetch(`files?path=${this.state.path}`);
        const data = await response.json();
        this.setState({files: data, loading: false});
    }
}
