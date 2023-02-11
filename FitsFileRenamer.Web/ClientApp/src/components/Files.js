import React, {Component} from 'react';

export class Files extends Component {
    static displayName = Files.name;

    constructor(props) {
        super(props);
        this.state = {files: [], path: '', loading: true};
        this.handleSelect = this.handleSelect.bind(this);
    }

    handleSelect(event) {
        console.log(event);
        //this.populateFilesData();
    }

    static renderFiles(files) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                <tr>
                    <th>FullPathName</th>
                    <th>Date</th>
                </tr>
                </thead>
                <tbody>
                {files.map(file =>
                    <tr key={file.FullPathName}>
                        <td>{file.FullPathName}</td>
                        <td>{file.Date}</td>
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
                <input directory="" webkitdirectory="" mozdirectory="" type="file" onChange={this.handleSelect} />
                {contents}
            </div>
        );
    }

    async populateFilesData() {
        const response = await fetch(`files?path=${this.state.path}`);
        const data = await response.json();
        this.setState({forecasts: data, loading: false});
    }
}
