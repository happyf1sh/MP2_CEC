#region Copyright (C) 2007-2008 Team MediaPortal

/*
    Copyright (C) 2007-2008 Team MediaPortal
    http://www.team-mediaportal.com
 
    This file is part of MediaPortal II

    MediaPortal II is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal II is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal II.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using MediaPortal.Core.FileEventNotification;

namespace MediaPortal.Core.Services.FileEventNotification
{

  /// <summary>
  /// Represents all data regarding a watched file,
  /// FileWatcherInfo is needed to subscribe and unsubscribe a watch.
  /// </summary>
  internal sealed class FileWatcherInfo : FileWatchInfo, IEquatable<FileWatchInfo>
  {

    #region Variables

    /// <summary>
    /// The unique ID.
    /// </summary>
    private int _id;
    /// <summary>
    /// The path to which the current FileWatcherInfo is subscribed.
    /// </summary>
    private string _subscribedPath;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the unique ID.
    /// -1 indicates that the ID isn't set yet.
    /// </summary>
    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    /// <summary>
    /// Gets or sets the path to which the current FileWatcherInfo is subscribed.
    /// </summary>
    public string SubscribedPath
    {
      get { return _subscribedPath; }
      set { _subscribedPath = value; }
    }

    #endregion

    #region Constructors

    public FileWatcherInfo(string path, bool includeSubdirectories, FileEventHandler eventHandler)
      : this(path, includeSubdirectories, eventHandler, new List<string>(), new List<FileWatchChangeType>())
    {
    }

    public FileWatcherInfo(string path, bool includeSubdirectories, FileEventHandler eventHandler, IList<string> filter)
      : this(path, includeSubdirectories, eventHandler, filter, new List<FileWatchChangeType>())
    {
    }

    public FileWatcherInfo(string path, bool includeSubdirectories, FileEventHandler eventHandler, IList<string> filter, IList<FileWatchChangeType> changeTypes)
      : base(path, includeSubdirectories, eventHandler, filter, changeTypes)
    {
      _id = -1;             // -1 indicates an illigal ID
      _subscribedPath = ""; // Avoids NullReferenceExceptions
    }

    public FileWatcherInfo(FileWatchInfo fileWatchInfo)
    {
      _id = -1;             // -1 indicates an illigal ID
      _subscribedPath = ""; // Avoids NullReferenceExceptions
      // Copy all variables from the specified FileWatchInfoS
      _changeTypes = fileWatchInfo.ChangeTypes;
      _eventHandler = fileWatchInfo.EventHandler;
      _filter = fileWatchInfo.Filter;
      _path = fileWatchInfo.Path;
      _includeSubdirectories = fileWatchInfo.IncludeSubdirectories;
    }

    #endregion

    #region IEquatable<FileWatchInfo> Members

    /// <summary>
    /// Returns whether the current object is equal to another object of type FileWatcherInfo.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(FileWatchInfo other)
    {
      if (other is FileWatcherInfo)
      {
        FileWatcherInfo nfo = (FileWatcherInfo) other;
        if (nfo._id != -1 || _id != -1)
          return (nfo._id == _id);
        // Else: both ID's are -1
        if (_path == nfo._path
            && _subscribedPath == nfo._subscribedPath
            && _includeSubdirectories == nfo._includeSubdirectories
            && _eventHandler == nfo._eventHandler
            && _changeTypes.Count == nfo._changeTypes.Count
            && _filter.Count == nfo._filter.Count)
        {
          for (int i = 0; i < _changeTypes.Count; i++)
          {
            if (_changeTypes[i] != nfo._changeTypes[i])
              return false;
          }
          for (int i = 0; i < _filter.Count; i++)
          {
            if (_filter[i] != nfo._filter[i])
              return false;
          }
          return true;
        }
        return false;
      }
      return false;
    }

    #endregion

  }
}