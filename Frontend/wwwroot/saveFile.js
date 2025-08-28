function saveFile(fileName, content, contentType)
{
    const link = document.createElement('a');

    const blob = new Blob([content], { type: contentType });
    const url = URL.createObjectURL(blob);

    link.href = url;
    link.download = fileName;

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);

    URL.revokeObjectURL(url);
}