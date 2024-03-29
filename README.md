[TOC]

# MGS.Compress

## Summary
- Compress and decompress file.

## Environment
- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Platform
- Windows.

## Demand
- Compress entrie[file or directorie] to dest file.
- Decompress file to dest dir.

## Usage
### Native

- Compress async.

  ```c#
  var fileDir = string.Format("{0}/TestFileDir/", Path.GetDirectoryName(filePath));
  var zipFile = string.Format("{0}/TestZipFile.zip", Path.GetDirectoryName(filePath));
  var rootDir = "TestRootDir";
  
  //CompressManager default with IonicCompressor to do compress and decompress tasks.
  CompressManager.Instance.CompressAsync(new string[] { filePath }, 
      zipFile, Encoding.UTF8, rootDir, true,
      progress =>
      {
          //TODO: Show progress.
      },
      (isSucceed, info, error) =>
      {
          //TODO: Show result.
      });
  ```
  
- Decompress async.

  ```C#
  var filePath = string.Format("{0}/TestZipFile.zip", Path.GetDirectoryName(filePath));
  var unzipDirPath = string.Format("{0}/TestZipDir/", Path.GetDirectoryName(filePath));
  
  //CompressManager default with IonicCompressor to do compress  and decompress tasks.
  CompressManager.Instance.DecompressAsync(filePath, unzipDirPath, true,
      progress =>
      {
          //TODO: Show progress.
      },
      (isSucceed, info, error) =>
      {
          //TODO: Show result.
      });
  ```

### Expand

- Custom compressor.

  ```C#
  //Implemente the interface ICompressor,
  public class CustomCompressor : ICompressor
  {
      public void Compress(IEnumerable<string> entries, string destFile,
          Encoding encoding, string directoryPathInArchive = null,
          bool clearBefor = true,
          Action<float> progressCallback = null,
          Action<bool, string, Exception> completeCallback = null)
      {
          //TODO: Implemente compress logic.
      }
  
      public void Decompress(string filePath, string destDir,
          bool clearBefor = true,
          Action<float> progressCallback = null,
          Action<bool, string, Exception> completeCallback = null)
      {
          //TODO: Implemente decompress logic.
      }
  }
  
  //and register to CompressManager.
  CompressManager.Instance.Compressor = new CustomCompressor();
  ```

## Demo
- Demos in the path "MGS.Packages/Compress/Demo/" provide reference to you.

------

Copyright © 2021 Mogoson.	mogoson@outlook.com